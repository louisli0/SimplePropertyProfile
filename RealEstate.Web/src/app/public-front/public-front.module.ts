import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { HomeComponent } from './components/Front/home/home.component';
import { FrontLayoutComponent } from './containers/front-layout/front-layout.component';
import { AboutComponent } from './components/Front/about/about.component';
import { ListingComponent } from './containers/listing/listing.component';
import { SearchComponent } from './containers/search/search.component';
import { SearchResultComponent } from './components/Search/search-result.component';

const routes: Routes = [
  {
    path: '',
    component: FrontLayoutComponent,
    children: [
      {
        path: 'about',
        component: AboutComponent,
      },
      {
        path: 'search',
        component: SearchComponent,
      },
      {
        path: 'listing/:id',
        component: ListingComponent,
      },
      {
        path: '',
        component: HomeComponent,
      },
    ],
  },
];

@NgModule({
  declarations: [
    FrontLayoutComponent,
    HomeComponent,
    AboutComponent,
    SearchComponent,
    ListingComponent,
    SearchResultComponent,
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    BrowserModule,
    RouterModule.forChild(routes),
  ],
  exports: [],
  providers: [],
})
export class PublicFrontModule {}
