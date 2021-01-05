import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import { DashboardLayoutComponent } from './containers/dashboard/dashboard-layout.component';
import { DBListingDisplayComponent } from './components/listings/listing-display/db-listing-display.component';
import { DbOverview } from './components/overview/db-overview.component';

const routes: Routes = [
  {
    path: 'dashboard',
    component: DashboardLayoutComponent,
    children: [
      {
        path: 'listings',
        component: DBListingDisplayComponent,
      },
      {
          path: '',
          component: DbOverview
      }
    ],
  },
];

@NgModule({
  declarations: [DashboardLayoutComponent, DbOverview, DBListingDisplayComponent],
  imports: [BrowserModule, RouterModule.forChild(routes)],
  exports: [],
  providers: [],
})

export class DashboardModule {}
