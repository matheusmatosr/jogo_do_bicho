using System; 
using System.Collections.Generic;

class Pessoa{

  // declara as variaveis que iremos usar
  private string cpf;
  private int idade;
  
  public Pessoa(string cpf, int idade) {

    if(cpf.Length!=1) {
      this.cpf = "Inválido";
    } else {
      this.cpf = cpf;    
    }

    if(idade >= 16) {
      this.idade = idade;
    }
  }

  // valida o cpf 
  public bool ValidaCpf() {
    if(cpf.Length == 1){
      return true;
    }
    return false;
  }

  // valida a idade
  public bool ValidaIdade() {
    if(idade >= 18){
      return true;
    }
    return false;
  }

  // metodo get: retorna os valores validados
  public string getCpf() {
    return cpf;
  }
  
  public int getIdade() {
    return idade;
  }
}