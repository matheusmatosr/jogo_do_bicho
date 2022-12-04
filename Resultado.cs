using System;
using System.Collections.Generic;

class Resultado {

  // declara o que as variáveis que iremos usar
  private string animalSorteado;
  private int numAnimalSorteado;
  int sorteio;
  public int valorPremio;
  public float novoValor;
  private string vencedores;
  private Aposta aposta_atual;
  int qtdVencedor = 0;

  
  public Resultado(Aposta my_apost) {
    aposta_atual = my_apost;
  }

  // pega a lista com os dados dos apostadores
  public List<Aposta> getListaApostadores() {
    return aposta_atual.getListaApostadores();
  }

  // realiza o sorteio
  public void setSorteio() {
    Random rdn = new Random();
    sorteio = rdn.Next(1,9);
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("===========================================");
    Console.WriteLine("================ Resultado ================");
    Console.WriteLine("===========================================");
    Console.WriteLine();
    Console.WriteLine($"Número sorteado: {sorteio}!");
    if(sorteio == 1 || sorteio == 2 || sorteio == 3){
      numAnimalSorteado = 1;
      animalSorteado = "Cavalo";
    } else if (sorteio == 4 || sorteio == 5 || sorteio == 6){
      numAnimalSorteado = 2;
      animalSorteado = "Galo";
    } else if(sorteio == 7 || sorteio == 8 || sorteio == 9){
      numAnimalSorteado = 3;
      animalSorteado = "Ganso";
    }
  }

  // confere com base no n° do sorteio qual foi o animal sorteado
  public void setConferirAnimal() {
    if(animalSorteado == "Cavalo") {
      Console.WriteLine("Animal sorteado >> Cavalo !!");
    } else if (animalSorteado == "Galo") {
      Console.WriteLine("Animal sorteado >> Galo !!");
    } else if (animalSorteado == "Ganso") {
      Console.WriteLine("Animal sorteado >> Ganso !!");
    }
  }

  // compara o n° sorteado com os escolhidos pelos apostadores e daí surge os vencedores
  public void setVencedor(){
    Console.WriteLine();

    List<Aposta> apostadores = aposta_atual.getListaApostadores();
    
    for(int i=0; i<apostadores.Count; i++){
      Aposta p = apostadores[i];
      if(p.getAnimal() == numAnimalSorteado){
        qtdVencedor++;
        vencedores = p.getNome();
        if(vencedores.Length > 2){
          Console.WriteLine($"O apostador {vencedores} teve seu animal sorteado !!");
        } 
        else{
          Console.WriteLine($"O apostador {vencedores} teve seu animal sorteado !!"); 
        }
      } 
    }
  }

  // trata o valor do premio conforme a quantidade de vencedores
  public void setValor() {
    
    valorPremio = 100000;
    if (qtdVencedor > 0) {
      novoValor = (valorPremio / qtdVencedor); 
    } else {
      novoValor = 100000;
    }
    Console.WriteLine();
    
    if (qtdVencedor >= 2) {
      Console.WriteLine($"O prêmio inicial é de R$ 100 mil, tivemos {qtdVencedor} sortudos e portanto o valor do prêmio atual é: ");
      Console.WriteLine();
      Console.WriteLine($">>> R$ {novoValor}. <<<");
    } else if (qtdVencedor == 1) {
      Console.WriteLine($"O prêmio inicial é de R$ 100 mil, tivemos somente 1 sortudo e portanto o valor do prêmio atual é: ");
      Console.WriteLine();
      Console.WriteLine($">>> R$ {valorPremio}. <<<");
    } else if (qtdVencedor == 0) {
      Console.WriteLine("Que pena, não tivemos ganhadores!");
    }
  }

  // metodo get: retorna os valores tratados
  public float getSorteio() {
    return sorteio;  
  }
  
  public string getConferirAnimal() {
    return animalSorteado;
  }
  
  public int getValor() {
    return valorPremio;
  }
  
  public string getVencedor() {
    return vencedores; 
  }
}