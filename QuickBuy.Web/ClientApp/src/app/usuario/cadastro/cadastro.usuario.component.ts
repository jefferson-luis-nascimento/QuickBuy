import { Component, OnInit } from "@angular/core";
import { Usuario } from "../../modelo/Usuario";
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";

@Component({
  selector: "cadastro-usuario",
  templateUrl: "cadastro.usuario.component.html",
  styleUrls: ["cadastro.usuario.component.css"]
})
export class CadastroUsuarioComponent implements OnInit {
    
  public usuario: Usuario;

  ngOnInit(): void {
    this.usuario = new Usuario();
  }

  constructor(private usuarioServico: UsuarioServico) {

  }

  public cadastrar(): void {
    this.usuarioServico.cadastrarUsuario(this.usuario)
      .subscribe(
        usuario_json => {

        },
        err => {

        }
      );
  }
}
