import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';

@Component({
    selector: 'battery',
    templateUrl: './battery.component.html',
    styleUrls: ['./battery.component.css']
})
export class BatteryComponent implements OnInit, OnDestroy {
    private sub: any;
    private baseUrl: string;
    public battery: Battery;
    
    constructor(private route: ActivatedRoute, private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
    }
    
    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            // FIXME: this is not working now that i changed the id to ObjectId
            // let id = +params['id'];
            // console.log('id: ' + id);
            // this.http.get(this.baseUrl + 'api/battery/' + id).subscribe(result => {
            //     this.battery = result.json() as Battery
            // }, error => console.error(error));
        });
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }
}

interface Battery {
    id: string;
    name: string;
    lipoVoltage: string;
    mah: string;
    cRating: string;
    plugType: string;
    weight: string;
    dimension: string;
    link: string;
}