import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Routes, RouterModule } from '@angular/router';
import { ListingFormComponent } from './components/listing-form/listing-form.component';
import { ListingDisplayComponent } from './components/listing-display/listing-display.component';

const routes: Routes = [
  { path: 'new', component: ListingFormComponent },
  { path: ':listingId', component: ListingDisplayComponent },
];

@NgModule({
  declarations: [ListingFormComponent, ListingDisplayComponent],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [],
  providers: [],
})
export class ListingModule {}
