# Projeto Toolkit Sigma

Este projeto foi desenvolvido como parte da disciplina de **Computação Científica** no curso de Ciência da Computação (UNIFESO).  
O objetivo é implementar, em um único aplicativo **Console em C# (.NET 9)**, um conjunto de módulos relacionados a fundamentos de linguagens formais, decidibilidade e reconhecimento.  
Cada módulo corresponde a um item avaliativo (AV1 e AV2).  

---

## 👨‍🎓 Autores
- **Otávio Medeiros Silva** — Matrícula: 06003157
- **Eduardo de Andrade Esplinio** — Matrícula: 06003445
- **João Gabriel Soares de Andrade Simões** — Matrícula: 06003848

---

## ⚙️ Como executar

### Pré-requisitos
- [.NET SDK 9.0+](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)  
- Git instalado  

### Passos
1. Clone o repositório:
   ```bash
   git clone https://github.com/otavioms/CompC.git
   cd CompC/ConsoleApp1

2. Restaure os pacotes:
   ```bash
   dotnet restore

3. Compile o projeto:
   ```bash
   dotnet build

4. Execute o projeto:
   ```bash
   dotnet run

---

## ✅ AV1 — Fundamentos práticos
Itens já implementados:

1. **Verificador de alfabeto e cadeia em Σ={a,b}**  
   - Entrada de símbolo e cadeia.  
   - Verifica se pertencem ao alfabeto.  
   - Saída: válido / inválido.  

2. **Classificador T/I/N por JSON**  
   - Carrega lista embutida em JSON.  
   - Usuário classifica cada item como **T** (tratável), **I** (intratável) ou **N** (não computável).  
   - Mostra resumo com acertos e erros.  

3. **Programa de decisão: termina com ‘b’?**  
   - Verifica se a cadeia termina com ‘b’.  
   - Saída: **SIM** ou **NAO**.  

4. **Avaliador proposicional básico**  
   - Entrada de valores de P, Q, R.  
   - Menu com pelo menos duas fórmulas (ex.: conjunção, disjunção, implicação).  
   - Opção para imprimir a **tabela-verdade completa** da fórmula escolhida.  

5. **Reconhecedor Σ={a,b}: L_par_a e L = { a b* }**  
   - Menu com duas linguagens:  
     - `L_par_a`: cadeias com número par de `a`.  
     - `L = { w | w = a b* }`.  
   - Validação do alfabeto antes da decisão.  
   - Saída: **ACEITA** ou **REJEITA**.  

---

## 🔜 AV2 — Decidibilidade, reconhecimento e modelos
Próximos módulos a implementar:

6. **Problema × Instância por JSON**  
   - Carregar frases em JSON e pedir ao usuário para classificar como **Problema (P)** ou **Instância (I)**.  
   - Mostrar acertos, erros e total.  

7. **Decisores: L_fim_b e L_mult3_b**  
   - Implementar dois decisores adicionais sobre Σ={a,b}:  
     - `L_fim_b`: palavras que terminam em `b`.  
     - `L_mult3_b`: palavras cujo número de `b’s` é múltiplo de 3.  

8. **Reconhecedores: pode não terminar**  
   - Demonstrar um reconhecedor que pode não finalizar em alguns casos.  
   - Permitir abortar por limite de passos configurável.  

9. **Detector ingênuo de loop + reflexão**  
   - Executar processo passo a passo, registrar estados e sinalizar repetição.  
   - Imprimir reflexão sobre falsos positivos/negativos.  

10. **Simulador de AFD de casos fixos**  
    - Definir um AFD simples no código.  
    - Mostrar estado atual a cada símbolo consumido.  
    - Indicar aceitação ou rejeição no final.  

