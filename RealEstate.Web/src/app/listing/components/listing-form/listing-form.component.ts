import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'listing-form',
    styleUrls: ['listing-form.component.scss'],
    template: `
    <div>
    <p>Listing Form</p>
    <form>
        <input type="text" placeholder="Descrition" />
        <input type="text" placeholder="Sale Type" />
        <input type="text" placeholder="Address"/>
        <input type="text" placeholder="Address"/>
        <input type (ngModel)="listingDetails.name">
        <button (click)="handleSubmit($event)">Submit</button>
    </form>
    </div>`
})

export class ListingFormComponent {
    @Input() listingDetails: any;
    @Output() updateData;

    constructor() {
        this.updateData = new EventEmitter();
    }

    handleSubmit(event) {
        event.preventDefault();
        console.log('hello');
        this.updateData.emit(this.listingDetails);
    }
}