import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'batteries',
    templateUrl: './batteries.component.html',
    styleUrls: ['./batteries.component.css']
})
export class BatteriesComponent {
    public batteries: Battery[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/battery').subscribe(result => {
            this.batteries = result.json() as Battery[];
        }, error => console.error(error));
    }
}

interface Battery {
    id: number;
    name: string;
    lipoVoltage: string;
    mah: string;
    cRating: string;
    plugType: string;
    weight: string;
    dimension: string;
    link: string;
}