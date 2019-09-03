import { Component } from "@angular/core";
import { Usuario } from "../../modelo/Usuario";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent {
  public usuario;
  public usuarioAutenticado: boolean;
  public usuarios = ["Usuario 1", "Usuario 2", "Usuario 3", "Usuario 4", "Usuario 5", "Usuario 6"];

  constructor() {
    this.usuario = new Usuario();
  }

  public entrar(): void {
    if (this.usuario.email == "teste@teste.com" && this.usuario.senha == "123") {
      this.usuarioAutenticado = true;
    }
  }
}
