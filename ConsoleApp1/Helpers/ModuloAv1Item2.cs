using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ConsoleApp1.Helpers
{
	public static class ModuloAv1Item2
	{
		// Classe para representar um problema
		public class Problema
		{
			public string Descricao { get; set; }
			public string RespostaCorreta { get; set; }
		}

		// Caminho do arquivo JSON
		private static readonly string CaminhoArquivoJson = "Data/problemas-tin.json";

		public static void ExecutarClassificadorTIN()
		{
			Console.Clear();
			Console.WriteLine("----------------------------------");
			Console.WriteLine("CLASSIFICADOR T/I/N POR JSON");
			Console.WriteLine("----------------------------------");
			Console.WriteLine("T = Tratável (Tempo Polinomial)");
			Console.WriteLine("I = Intratável (NP-Completo/NP-Difícil)");
			Console.WriteLine("N = Não Computável (Indecidível)");
			Console.WriteLine();

			// Carregar problemas do arquivo JSON
			List<Problema> problemas = CarregarProblemasDoArquivo();

			if (problemas == null)
			{
				Console.WriteLine("Pressione qualquer tecla para continuar...");
				Console.ReadKey();
				return;
			}

			int totalProblemas = problemas.Count;
			int acertos = 0;
			int erros = 0;

			// Apresentar cada problema ao usuário
			for (int i = 0; i < problemas.Count; i++)
			{
				Console.WriteLine($"=== PROBLEMA {i + 1}/{totalProblemas} ===");
				Console.WriteLine($"Descrição: {problemas[i].Descricao}");
				Console.WriteLine();
				Console.Write("Classificação (T/I/N): ");

				string resposta = Console.ReadLine()?.ToUpper().Trim();

				// Validar entrada
				if (string.IsNullOrEmpty(resposta) ||
					(resposta != "T" && resposta != "I" && resposta != "N"))
				{
					Console.WriteLine("ENTRADA INVÁLIDA: Digite apenas T, I ou N.");
					Console.WriteLine($"Resposta correta era: {problemas[i].RespostaCorreta}");
					erros++;
				}
				else
				{
					// Verificar se está correto
					if (resposta == problemas[i].RespostaCorreta)
					{
						Console.WriteLine("✓ CORRETO!");
						acertos++;
					}
					else
					{
						Console.WriteLine($"✗ INCORRETO. Resposta correta: {problemas[i].RespostaCorreta}");
						erros++;
					}
				}

				Console.WriteLine();

				// Pausar entre perguntas (exceto na última)
				if (i < problemas.Count - 1)
				{
					Console.WriteLine("Pressione qualquer tecla para continuar...");
					Console.ReadKey();
					Console.WriteLine();
				}
			}

			// Mostrar resumo final
			MostrarResumoFinal(totalProblemas, acertos, erros);

			Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
			Console.ReadKey();
		}

		private static List<Problema> CarregarProblemasDoArquivo()
		{
			try
			{
				// Verificar se o arquivo existe
				if (!File.Exists(CaminhoArquivoJson))
				{
					Console.WriteLine($"ERRO: Arquivo não encontrado: {CaminhoArquivoJson}");
					Console.WriteLine("Verifique se o arquivo está na pasta correta do projeto.");
					return null;
				}

				// Ler conteúdo do arquivo
				string conteudoJson = File.ReadAllText(CaminhoArquivoJson);

				if (string.IsNullOrWhiteSpace(conteudoJson))
				{
					Console.WriteLine("ERRO: Arquivo JSON está vazio.");
					return null;
				}

				// Deserializar JSON
				List<Problema> problemas = JsonSerializer.Deserialize<List<Problema>>(conteudoJson);

				if (problemas == null || problemas.Count == 0)
				{
					Console.WriteLine("ERRO: Nenhum problema encontrado no arquivo JSON.");
					return null;
				}

				Console.WriteLine($"✓ {problemas.Count} problemas carregados com sucesso!");
				Console.WriteLine();

				return problemas;
			}
			catch (JsonException ex)
			{
				Console.WriteLine($"ERRO: Formato JSON inválido: {ex.Message}");
				return null;
			}
			catch (UnauthorizedAccessException)
			{
				Console.WriteLine($"ERRO: Sem permissão para acessar o arquivo: {CaminhoArquivoJson}");
				return null;
			}
			catch (DirectoryNotFoundException)
			{
				Console.WriteLine($"ERRO: Diretório não encontrado: {Path.GetDirectoryName(CaminhoArquivoJson)}");
				return null;
			}
			catch (IOException ex)
			{
				Console.WriteLine($"ERRO: Problema ao ler arquivo: {ex.Message}");
				return null;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"ERRO: Erro inesperado: {ex.Message}");
				return null;
			}
		}

		private static void MostrarResumoFinal(int total, int acertos, int erros)
		{
			Console.WriteLine("==============================");
			Console.WriteLine("         RESUMO FINAL");
			Console.WriteLine("==============================");
			Console.WriteLine($"Total de problemas: {total}");
			Console.WriteLine($"Acertos: {acertos}");
			Console.WriteLine($"Erros: {erros}");

			double percentualAcerto = total > 0 ? (double)acertos / total * 100 : 0;
			Console.WriteLine($"Percentual de acerto: {percentualAcerto:F1}%");

			Console.WriteLine();

			// Feedback baseado na performance
			if (percentualAcerto >= 80)
			{
				Console.WriteLine("🎉 Excelente desempenho!");
			}
			else if (percentualAcerto >= 60)
			{
				Console.WriteLine("👍 Bom desempenho!");
			}
			else if (percentualAcerto >= 40)
			{
				Console.WriteLine("📚 Continue estudando!");
			}
			else
			{
				Console.WriteLine("💪 Precisa revisar os conceitos!");
			}

			Console.WriteLine();
		}
	}
}