import { Component } from "@angular/core";

@Component({
  selector: "app-produto",
  template: "<html><body>getNome()</body></html>"
})
export class ProdutoComponent {
  nome: string;

  getNome(): string {
    return "Samsung";
  }
}
