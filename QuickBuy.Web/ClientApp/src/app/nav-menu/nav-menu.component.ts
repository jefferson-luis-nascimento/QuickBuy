import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UsuarioServico } from '../servicos/usuario/usuario.servico';
import { Usuario } from '../modelo/Usuario';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private router: Router, private usuarioServico: UsuarioServico) {

  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public usuarioLogado(): boolean {
    return this.usuarioServico.usuario_autenticado();
  }

  public sair(): void {
    this.usuarioServico.limpar_sessao();
    this.router.navigate(['/']);
  }

  public get usuario(): Usuario {
    return this.usuarioServico.usuario;
  }
}
