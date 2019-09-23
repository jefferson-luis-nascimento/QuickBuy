import { Component, OnInit } from "@angular/core";
import { Produto } from "../modelo/produto";
import { ProdutoServico } from "../servicos/produto/produto.servico";

@Component({
  selector: "app-produto",
  templateUrl: "produto.component.html",
  styleUrls: ["produto.component.css"]
})
export class ProdutoComponent implements OnInit {

  public produto: Produto;
  public arquivoSelecionado: File;
  public ativar_spinner: boolean;
  public nomeArquivoSelecionado: string = "Escolha uma foto";
  public mensagem: string;

  ngOnInit(): void {
    this.produto = new Produto();
  }

  constructor(private produtoServico: ProdutoServico) {

  }

  public cadastrar(): void {
    this.ativarSpinner();
    this.mensagem = '';
    this.produtoServico.cadastrar(this.produto)
      .subscribe(
        produto => {
          this.produto = produto;
          this.desativarSpinner();
        },
        err => {
          this.mensagem = err.error;
          console.log(err.error);
          this.desativarSpinner();
        }
      );
    
  }

  public inputChange(files: FileList): void {
    this.ativarSpinner();
    this.arquivoSelecionado = files[0];
    this.produtoServico.enviarArquivo(this.arquivoSelecionado)
      .subscribe(
        nomeArquivo => {
          this.produto.nomeArquivo = nomeArquivo;
          this.nomeArquivoSelecionado = nomeArquivo;
          this.desativarSpinner();
        },
        err => {
          console.log(err.error.message)
          this.desativarSpinner();
        }
      );
    
  }

  public ativarSpinner() {
    this.ativar_spinner = true;
  }

  public desativarSpinner() {
    this.ativar_spinner = false;
  }
}
