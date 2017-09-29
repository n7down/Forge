import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { BatteryComponent } from './components/battery/battery.component';
import { CreateBatteryComponent } from './components/create-battery/create-battery.component';
import { BatteriesComponent } from './components/batteries/batteries.component';
import { FlightControllersComponent } from './components/flight-controllers/flight-controllers.component';
import { DocumentationComponent } from './components/documentation/documentation.component';
import { AboutComponent } from './components/about/about.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        DashboardComponent,
        BatteryComponent,
        CreateBatteryComponent,
        BatteriesComponent,
        FlightControllersComponent,
        DocumentationComponent,
        AboutComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
            { path: 'dashboard', component: DashboardComponent },
            { path: 'battery/:id', component: BatteryComponent },
            { path: 'create/battery', component: CreateBatteryComponent },
            { path: 'batteries', component: BatteriesComponent },
            { path: 'flight-controllers', component: FlightControllersComponent },
            { path: 'documentation', component: DocumentationComponent },
            { path: 'about', component: AboutComponent },
            { path: '**', redirectTo: 'dashboard' }
        ])
    ]
})
export class AppModuleShared {
}
