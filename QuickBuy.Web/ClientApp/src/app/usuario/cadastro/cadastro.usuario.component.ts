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
  public ativar_spinner: boolean;
  public mensagem: string;
  public usuario_cadastrado: boolean;

  ngOnInit(): void {
    this.usuario = new Usuario();
  }

  constructor(private usuarioServico: UsuarioServico) {

  }

  public cadastrar(): void {
    this.ativar_spinner = true;

    this.usuarioServico.cadastrarUsuario(this.usuario)
      .subscribe(
        usuario_json => {
          this.mensagem = "";
          this.usuario_cadastrado = true;
        },
        err => {
          this.mensagem = err.error;
        }
    );
    this.ativar_spinner = false;
  }
}
