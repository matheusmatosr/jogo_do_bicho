using System;
using System.IO;
using System.Collections.Generic;

class CasaAp {
  
  Aposta myApost;

  // declara a classe Aposta da qual iremos usar e os seus set 
  public CasaAp() {
    myApost = new Aposta();
    myApost.setAnimal(1);
    myApost.setQuantidade(5);
    myApost.setValor(100);
    myApost.setAnimal(1);
    myApost.setQuantidade(1);
    myApost.setValor(1);
  }

  // carrega os dados do apostador para o arquivo txt
  public bool CarregarDadosApostador(string dados) {

    string[] linhas = File.ReadAllLines(dados);

    foreach (string linha in linhas) {
      string[] inf = linha.Split(";");
      string nome = inf[0];
      int animal = int.Parse(inf[1]);
      int quantidade = int.Parse(inf[2]);
      int valor = int.Parse(inf[3]);
      myApost.EmbarcarApostador(new Aposta(nome, animal, quantidade, valor));
    }
      return true;
  }

  // menu principal
  public void Menu() {

    // declara as variaveis
    int jogadores = 0;
    int valor;
    int idade;
    int animal;
    string def;
    string nome, cpf;
    List<Pessoa> pessoas = new List<Pessoa>();
    List<Aposta> apostadores = new List<Aposta>();

    Console.WriteLine("========== Bet27: La casa de Apuestas ==========");
    Console.WriteLine();
    Console.WriteLine("#JogueComResponsabilidade");
    Console.WriteLine();
    Console.Write("Informe a quantidade de apostadores: ");
    jogadores = Convert.ToInt32(Console.ReadLine());

    // rodará o jogo com base na qtd informada de jogadores
    for (int i = 1; i <= jogadores; i++) {
      Console.WriteLine();
      Console.Write("Cpf: ");
      cpf = Console.ReadLine();
      Console.Write("Idade: ");
      idade = Convert.ToInt32(Console.ReadLine());

      // adiciona os dados informados acima para a lista
      Pessoa p = new Pessoa(cpf, idade);
      pessoas.Add(p);

      // ocorre a validação da idade e do cpf chamando as funções criadas na classe Aposta
      if (p.ValidaIdade() == true && p.ValidaCpf() == true) {

        // escolha do animal desejado
        Console.WriteLine();
        Console.Write("Nome: ");
        nome = Console.ReadLine();
        myApost.ImprimeMenu();
        Console.WriteLine();
        Console.Write($"{nome}, escolha o número do animal desejado: ");
        animal = Convert.ToInt32(Console.ReadLine());

        switch (animal) {
          case 1:
            Console.WriteLine();
            Console.Write("Quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());
            valor = quantidade * 20;
            myApost.EmbarcarApostador(new Aposta(nome, animal, quantidade, valor));
            break;
          case 2:
            Console.WriteLine();
            Console.Write("Quantidade: ");
            quantidade = Convert.ToInt32(Console.ReadLine());
            valor = quantidade * 20;
            myApost.EmbarcarApostador(new Aposta(nome, animal, quantidade, valor));
            break;
          case 3:
            Console.WriteLine();
            Console.Write("Quantidade: ");
            quantidade = Convert.ToInt32(Console.ReadLine());
            valor = quantidade * 20;
            myApost.EmbarcarApostador(new Aposta(nome, animal, quantidade, valor));
            break;
          default:
            Console.WriteLine();
            myApost.ValorInvalido();
            break;
        }

        // caso a pessoa tenha escolhido um n° de animal válido, tera acesso ao menu do apostador 
        if (animal >= 1 && animal <= 3) {
          Console.WriteLine();
          Console.WriteLine("!! MENU DO APOSTADOR !!");
          Console.WriteLine("1 - Imprimir relatório dos apostadores.");
          Console.WriteLine("2 - Recibo das compras");
          Console.WriteLine("3 - Sair");
          Console.WriteLine();
          def = Console.ReadLine();
          
          switch (def) {
            case "1":
              myApost.ImprimeRelatorioApostadores();
              break;

            case "2":
              Console.WriteLine();
              Console.WriteLine("Segue os recibos das compras realizadas:");
              myApost.ImprimeRecibo();
              break;

            case "3":
              Console.WriteLine();
              Console.WriteLine("Obrigado!");
              break;

            default:
              Console.WriteLine();
              myApost.ValorInvalido();
              break;
          }
        } 
        // caso tenha escolhido um n° de animal indisponivel
        else {
          Console.WriteLine();
          Console.WriteLine("Dica >> Jogue novamente com os valores corretos!");
        }
      }
      // caso a pessoa seja reprovada na validação por idade insuficiente ou cpf inválido
      else {
        myApost.ImprimeTriste();
      }
    }
      // chama a classe Resultado e os seus respectivos set
      Resultado result = new Resultado(myApost);
      result.setSorteio();
      result.setConferirAnimal();
      result.setVencedor();
      result.setValor();
    }

  public static void Main(string[] args) {
    CasaAp aposta = new CasaAp();
    aposta.Menu();
  }
}