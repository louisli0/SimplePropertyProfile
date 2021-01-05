import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-search-result',
    styleUrls: ['search-result.component.scss'],
    template: `
    <div>
        <p>Results</p>
        <div *ngIf="data.length > 0; else noData">
            <div *ngFor="let results of data">
                <p>TODO: Results listing</p>
            </div>
        </div>

        <ng-template #noData>
            <p>No Results</p>
        </ng-template>
    </div>`
})

export class SearchResultComponent {
    @Input() data: [];


}