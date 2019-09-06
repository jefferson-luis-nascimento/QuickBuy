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

  ngOnInit(): void {
    this.produto = new Produto();
  }

  constructor(private produtoServico: ProdutoServico) {

  }

  public cadastrar(): void {
    this.produtoServico.cadastrar(this.produto)
      .subscribe(
        produto => {
          console.log(produto);
        },
        err => {
          console.log(err.error);
        }
      );
  }
}
