import { Component } from '@angular/core';
import { RouterOutlet } from "@angular/router";
import { NavbarComponent } from "../../../shared/components/navbar/navbar.component";
import { FooterComponent } from "../../../shared/components/footer/footer.component";

@Component({
  selector: 'app-land-layout',
  imports: [RouterOutlet, NavbarComponent, FooterComponent],
  templateUrl: './land-layout.component.html',
  styleUrl: './land-layout.component.css',
})
export class LandLayoutComponent {

}
