import { Component } from '@angular/core';

@Component({
  selector: 'app-front-layout',
  styleUrls: ['front-layout.component.scss'],
  template: `<div>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <div class="container-fluid">
        <button
          class="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarTogglerDemo01"
          aria-controls="navbarTogglerDemo01"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarTogglerDemo01">
          <a class="navbar-brand" href="#">Real Estate</a>
          <ul class="navbar-nav me-auto mb-2 mb-lg-0">
            <li class="nav-item">
              <a class="nav-link active" aria-current="page" routerLink="/"
                >Home</a
              >
            </li>
            <li class="nav-item">
              <a class="nav-link" routerLink="/about">About</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" routerLink="/search">Search</a>
            </li>
          </ul>
        </div>
      </div>
    </nav>

    <div class="container">
      <router-outlet></router-outlet>
    </div>
  </div>`,
})
export class FrontLayoutComponent {}
