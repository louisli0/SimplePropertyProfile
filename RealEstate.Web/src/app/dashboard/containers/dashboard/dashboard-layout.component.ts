import { Component } from '@angular/core';

@Component({
    selector: 'dashboard-layout',
    styleUrls: ['dashboard-layout.component.scss'],
    template: `
    <div>
        <nav class="navbar navbar-dark bg-primary">
            <h4>Dashboard</h4>
        </nav>

        <div class="sidebar">
            <p>Sidebar</p>
        </div>

        <div class="container">
            <router-outlet></router-outlet>
        </div>
    </div>`
})

export class DashboardLayoutComponent {

}