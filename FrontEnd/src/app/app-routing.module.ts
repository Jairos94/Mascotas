import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//componentes
import { AgregarEditarMascotaComponent } from './components/agregar-editar-mascota/agregar-editar-mascota.component';
import { ListadoMascotasComponent } from './components/listado-mascotas/listado-mascotas.component';
import { VerMascotaComponent } from './components/ver-mascota/ver-mascota.component';

const routes: Routes = [
  {path:'',redirectTo:'listado-mascotas',pathMatch:'full'},
  {path:'listado-mascotas',component:ListadoMascotasComponent},
  {path:'agregar-mascota',component:AgregarEditarMascotaComponent},
  {path:'ver-mascota/:id',component:VerMascotaComponent},
  {path:'edtitar-mascota/:id',component:AgregarEditarMascotaComponent},
  {path:'**',redirectTo:'listado-mascotas',pathMatch:'full'},


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
