import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UsuarioService } from '../../Services/usuario.service';
import { UsuarioRegistradoAn } from '../../Models/UsuarioRegistradoAn';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrl: './registro.component.css'
})
export class RegistroComponent {
  form: FormGroup;

  constructor(private formBuilder: FormBuilder, private usuarioService: UsuarioService, private toastr: ToastrService) {
    this.form = this.formBuilder.group({ 
      id: 0, 
      userName: ['', [Validators.required]], 
      email: ['', [Validators.required, Validators.pattern(/[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}/)]],
      passwordAng: ['', [Validators.required, Validators.minLength(7)]]
    })
  }

  ngOnInit(): void {

  }

  guardarUsuario() {
    const usuario: UsuarioRegistradoAn = {
      userName: this.form.get('userName')?.value,
      email: this.form.get('email')?.value,
      password: this.form.get('passwordAng')?.value

    }
    this.usuarioService.guardarUsuario(usuario).subscribe(data => {
      this.toastr.success('Registro Agregado', 'El usuario fue agregado');
      this.form.reset();
    })
  }
}
