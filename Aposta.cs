using System;
using System.Collections.Generic;

class Aposta {

  // declara as variaveis que iremos usar
  private string nome;
  private int animal;
  private int quantidade;
  private int valor;
  private List<Aposta> apostadores;
  
  public Aposta() {
    animal = 1;
    quantidade = 5;
    valor = 100;
    apostadores = new List<Aposta>();
  }

  // trata as variaveis
  public Aposta(string nome, int animal, int quantidade, int valor) {
    this.nome = nome;
    this.animal = animal;
    this.quantidade = quantidade;
    this.valor = valor;
    apostadores = new List<Aposta> ();
  }

  // trata a lista que será guardada os dados do apostador
  public List<Aposta> getListaApostadores() {
    return apostadores;
  }
  
  public int QuantidadeApostadores() {
    return apostadores.Count;
  }

  // capacidade máxima de pessoas jogando é de 100 pessoas, essa função que valida a quantidade e embarca o apostador no jogo caso tenha vaga.
  public bool EmbarcarApostador(Aposta i) {
    if(apostadores.Count <= 100){
       apostadores.Add(i);
       return true;
    } else
      return false;
  }

  // metodo set: trata os valores
  public void setNome(string n) {
    nome = n.ToUpper();
  }

  public void setQuantidade(int quantidade) {
    this.quantidade = quantidade;
  }

  public void setAnimal(int animal) {
    this.animal = animal;
  }

  public void setValor(int valor) {
    this.valor = valor;
  }

  // metodo get: retorna os valores tratados
  public string getNome() {
    return nome;
  }
  
  public int getAnimal() {
    return animal;
  }

  public int getQuantidade() {
    return quantidade;
  }

  public int getValor() {
    return valor;
  }

  // menu com as informações
  public void ImprimeMenu() {
    Console.WriteLine();
    Console.WriteLine("------------------------------------");
    Console.WriteLine(">>> Cada animal custa R$20,00! <<<");
    Console.WriteLine("------------------------------------");
    Console.WriteLine();
    Console.WriteLine("<<< Valor do premio: R$ 100 mil >>>");
    Console.WriteLine("------------------------------------");
    Console.WriteLine();
    Console.WriteLine("Escolha um dos números dos animais disponíveis: ");
    Console.WriteLine("1 - Cavalo (n° 1, 2, 3)");
    Console.WriteLine("2 - Galo (n° 4, 5, 6)");
    Console.WriteLine("3 - Ganso (n° 7, 8, 9)");
    Console.WriteLine();    
  }

  // imprime relatorio com as carecteristicas dos apostadores
  public void ImprimeRelatorioApostadores() {
    Console.WriteLine();
    Console.WriteLine("=====================================================");
    Console.WriteLine("============ Relatório de Apostadores ===============");
    Console.WriteLine("=====================================================");

    // acessa a lista para pegar as informações
    for(int i=0; i<apostadores.Count; i++) {
      Aposta p = apostadores[i];
      Console.WriteLine($"Pessoa {i+1}: {p.getNome()} ");      
      if(p.animal == 1){
        Console.WriteLine($"Animal: Cavalo");
      } else if (p.animal == 2){
        Console.WriteLine($"Animal: Galo");
      } else if (p.animal == 3){
        Console.WriteLine($"Animal: Ganso");
      }
      Console.WriteLine($"Qtd: {p.getQuantidade()}");
      Console.WriteLine($"Valor: R${p.getValor()}");
      Console.WriteLine();
    }
  }

  // imprime mensagem caso não tenha idade suficiente para jogar
  public void ImprimeTriste() {
    Console.WriteLine();
    Console.WriteLine("Ops.....");
    Console.WriteLine("Idade insuficiente para jogar ou cpf inválido!");
  }

  // imprime mensagem caso valor seja invalido
  public void ValorInvalido() {
    Console.WriteLine("Ops... Valor inválido!");
  }

  // imprime os recibos com as informações de todas as apostas
  public void ImprimeRecibo() {
    for(int i=0; i<apostadores.Count; i++){
      Aposta p = apostadores[i];
      Console.WriteLine();
      Console.WriteLine($"----- Recibo da compra n°{i+1} -----");
      Console.WriteLine($"Jogador >> {p.getNome()}");
      Console.WriteLine($"N° do animal escolhido >> {p.getAnimal()}");
      Console.WriteLine($"Quantidade >> {p.getQuantidade()}");
      Console.WriteLine($"Valor Total >> R${p.getValor()}"); 
    }
  }
}