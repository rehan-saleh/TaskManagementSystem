import { RoleService } from "./../services/role.service";
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { BaseService } from "../services/base.service";
import { AuthGuard } from "src/services/auth.guard";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { LoginComponent } from "./login/login.component";
import { HomeComponent } from "./home/home.component";
import { AuthService } from "src/services/login.service";
import { SidebarModule } from "./shared/sidebar/sidebar.module";

@NgModule({
  declarations: [AppComponent, LoginComponent, HomeComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,

    SidebarModule
  ],
  providers: [BaseService, AuthGuard, AuthService, RoleService],
  bootstrap: [AppComponent]
})
export class AppModule {}
