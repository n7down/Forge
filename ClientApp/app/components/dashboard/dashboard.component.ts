import { Component, Inject } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';

@Component({
    selector: 'dashboard',
    templateUrl: './dashboard.component.html'
})
export class DashboardComponent {
    private baseUrl: string;

    public data: string | undefined;
    public input: string = 'fc';

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        let options = new RequestOptions({ headers: headers });
		this.http.get(this.baseUrl + 'api/v1/' + this.input, options).subscribe(result => {
            var flightControllers = result.json();
            this.data = JSON.stringify(flightControllers, null, 2);
        }, error => console.error(error));
    }

    public enterPressed() {
        this.request();
    }

    public request() {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        let options = new RequestOptions({ headers: headers });
		this.http.get(this.baseUrl + 'api/v1/' + this.input, options).subscribe(result => {
            var d = result.json();
            this.data = JSON.stringify(d, null, 2);
        }, error => console.error(error));
    }
}