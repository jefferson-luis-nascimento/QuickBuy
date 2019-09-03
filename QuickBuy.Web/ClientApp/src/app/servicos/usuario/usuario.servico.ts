import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Usuario } from "../../modelo/Usuario";


@Injectable({
  providedIn: "root"
})
export class UsuarioServico {

  private baseUrl: string;
  private _usuario: Usuario;

  get usuario(): Usuario {
    let usuario_json = sessionStorage.getItem("usuario-autenticado");

    this._usuario = JSON.parse(usuario_json);

    return this._usuario;
  }

  set usuario(usuario: Usuario) {
    this._usuario = usuario;

    sessionStorage.setItem("usuario-autenticado", JSON.stringify(this._usuario));
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public VerificarUsuario(usuario: Usuario): Observable<Usuario> {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      email: usuario.email,
      senha: usuario.senha
    }

    return this.http.post<Usuario>(this.baseUrl + "api/usuario/VerificarUsuario", body, { headers });
  }

  public usuario_autenticado(): boolean {
    //alert(this._usuario)
    return this._usuario != null && this._usuario.email != "" && this._usuario.senha != "";
  }

  public limpar_sessao(): void {
    sessionStorage.setItem("usuario-autenticado", "");
    this._usuario = null;
  }
}

