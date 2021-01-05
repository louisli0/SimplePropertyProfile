import { Component } from '@angular/core';

@Component({
    selector: 'app-search',
    styleUrls: ['search.component.scss'],
    template: `
    <div>
    <div class="mb-3 container">
        <p>Search Listings</p>
        <caption>Find Listings currently Available</caption>
    </div>
    
    <div class="mb-3">
        <div>
            Searching For: {{searchTerm}}
        </div>
            <input type="text" [value]="searchTerm" (input)="searchTerm=$event.target.value"/> 
            <button type="button" (click)="handleSearch()">Search</button>
        </div>
    </div>

    <div class="container card">
        <app-search-result 
        data="{{data}}"
        ></app-search-result>
    </div>
    `

})

export class SearchComponent {
    searchTerm: string = "";
    data: [];

    handleSearch(): void {
        console.log(this.searchTerm)
    }

    handleListing(): void {
        console.log('listing')
    }
}