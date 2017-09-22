import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'batteries',
    templateUrl: './batteries.component.html'
})
export class BatteriesComponent {
    public batteries: Batteries[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/batteries').subscribe(result => {
            this.batteries = result.json() as Batteries[];
        }, error => console.error(error));
    }
}

interface Batteries {
    Name: string;
    LipoVoltage: string;
    MAh: string;
    CRating: string;
    PlugType: string;
    Weight: string;
    Dimension: string;
    Link: string;
}
    