import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DocumentationComponent } from './components/documentation/documentation.component';
import { AboutComponent } from './components/about/about.component';

import { BatteryComponent } from './components/battery/battery.component';
import { CreateBatteryComponent } from './components/create-battery/create-battery.component';
import { EditBatteryComponent } from './components/edit-battery/edit-battery.component';
import { BatteriesComponent } from './components/batteries/batteries.component';

import { FlightControllerComponent } from './components/flight-controller/flight-controller.component';
import { CreateFlightControllerComponent } from './components/create-flight-controller/create-flight-controller.component';
import { EditFlightControllerComponent } from './components/edit-flight-controller/edit-flight-controller.component';
import { FlightControllersComponent } from './components/flight-controllers/flight-controllers.component';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        DashboardComponent,
        DocumentationComponent,
        AboutComponent,

        BatteryComponent,
        CreateBatteryComponent,
        EditBatteryComponent,
        BatteriesComponent,

        FlightControllerComponent,
        CreateFlightControllerComponent,
        EditFlightControllerComponent,
        FlightControllersComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
            { path: 'dashboard', component: DashboardComponent },

            { path: 'documentation', component: DocumentationComponent },
            { path: 'about', component: AboutComponent },

            { path: 'battery/:id', component: BatteryComponent },
            { path: 'create/battery', component: CreateBatteryComponent },
            { path: 'edit/battery/:id', component: EditBatteryComponent },
            { path: 'batteries', component: BatteriesComponent },

            { path: 'flight-controller/:id', component: FlightControllerComponent },
            { path: 'create/flight-controller', component: CreateFlightControllerComponent },
            { path: 'edit/flight-controller', component: EditFlightControllerComponent },
            { path: 'flight-controllers', component: FlightControllersComponent },

            { path: '**', redirectTo: 'dashboard' }
        ])
    ]
})
export class AppModuleShared {
}
