using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ConsoleApp1.Helpers
{
	public static class ModuloAv2Item1
	{
		// Classe para representar um item (problema / instância)
		public class ItemProblemaInstancia
		{
			public string Descricao { get; set; }
			public string RespostaCorreta { get; set; }
		}

		// Caminho do arquivo JSON
		private static readonly string CaminhoArquivoJson = "Data/itens-problema.json";

		public static void ExecutarClassificadorProblemaInstancia()
		{
			Console.Clear();
			Console.WriteLine("=== CLASSIFICADOR PROBLEMA x INSTÂNCIA ===");
			Console.WriteLine("Classifique cada item como:");
			Console.WriteLine("P - Problema (descrição geral)");
			Console.WriteLine("I - Instância (caso específico)");
			Console.WriteLine();

			// Carregar itens do arquivo JSON
			List<ItemProblemaInstancia> itens = CarregarItensDoArquivo();

			if (itens == null)
			{
				Console.WriteLine("Pressione qualquer tecla para continuar...");
				Console.ReadKey();
				return;
			}

			int total = itens.Count;
			int acertos = 0;
			int erros = 0;

			for (int i = 0; i < itens.Count; i++)
			{
				Console.WriteLine($"Item {i + 1}/{total}");
				Console.WriteLine($"Descrição: {itens[i].Descricao}");
				Console.WriteLine();
				Console.Write("Classificação (P/I): ");

				string resposta = Console.ReadLine()?.ToUpper().Trim();

				if (string.IsNullOrEmpty(resposta) || (resposta != "P" && resposta != "I"))
				{
					Console.WriteLine("ENTRADA INVÁLIDA: Digite apenas P ou I.");
					Console.WriteLine($"Resposta correta era: {itens[i].RespostaCorreta}");
					erros++;
				}
				else
				{
					if (resposta == itens[i].RespostaCorreta)
					{
						Console.WriteLine("✓ CORRETO!");
						acertos++;
					}
					else
					{
						Console.WriteLine($"✗ INCORRETO. Resposta correta: {itens[i].RespostaCorreta}");
						erros++;
					}
				}

				Console.WriteLine();
			}

			MostrarResumoFinal(total, acertos, erros);

			Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
			Console.ReadKey();
		}

		private static List<ItemProblemaInstancia> CarregarItensDoArquivo()
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
				List<ItemProblemaInstancia> itens = JsonSerializer.Deserialize<List<ItemProblemaInstancia>>(conteudoJson);

				if (itens == null || itens.Count == 0)
				{
					Console.WriteLine("ERRO: Nenhum item encontrado no arquivo JSON.");
					return null;
				}

				Console.WriteLine($"✓ {itens.Count} itens carregados com sucesso!");
				Console.WriteLine();

				return itens;
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
			Console.WriteLine($"Total de itens: {total}");
			Console.WriteLine($"Acertos: {acertos}");
			Console.WriteLine($"Erros: {erros}");

			double percentualAcerto = total > 0 ? (double)acertos / total * 100 : 0;
			Console.WriteLine($"Percentual de acerto: {percentualAcerto:F1}%");

			Console.WriteLine();

			if (percentualAcerto >= 80)
			{
				Console.WriteLine("Excelente desempenho!");
			}
			else if (percentualAcerto >= 60)
			{
				Console.WriteLine("Bom desempenho!");
			}
			else if (percentualAcerto >= 40)
			{
				Console.WriteLine("Continue estudando!");
			}
			else
			{
				Console.WriteLine("Precisa revisar os conceitos!");
			}

			Console.WriteLine();
		}
	}
}