import { Component } from '@angular/core';
import { CarouselModule, OwlOptions } from 'ngx-owl-carousel-o';

@Component({
  selector: 'app-landing',
  imports: [ CarouselModule ],
  templateUrl: './landing.component.html',
  styleUrl: './landing.component.css',
})
export class LandingComponent {

// const image = document.getElementById("beforeAfterImage");
// const divider = document.getElementById("divider");

// divider.addEventListener("mousedown", startSliding);

// function startSliding() {
//   document.addEventListener("mousemove", moveDivider);
//   document.addEventListener("mouseup", stopSliding);
// }

// function moveDivider(e) {
//   const rect = image.getBoundingClientRect();
//   let x = e.clientX - rect.left;

//   if (x < 0) x = 0;
//   if (x > rect.width) x = rect.width;

//   divider.style.left = x + "px";

//   const percent = (x / rect.width) * 100;
//   image.style.clipPath = `inset(0 0 0 ${percent}%)`;
// }

// function stopSliding() {
//   document.removeEventListener("mousemove", moveDivider);
// }



}
