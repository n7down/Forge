import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { QuadcopterWorkbenchAPIComponent } from './components/qcwapi/qcwapi.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { DocumentationComponent } from './components/documentation/documentation.component';
import { AboutComponent } from './components/about/about.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        QuadcopterWorkbenchAPIComponent,
        DocumentationComponent,
        AboutComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'qcwapi', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'qcwapi', component: QuadcopterWorkbenchAPIComponent },
            { path: 'documentation', component: DocumentationComponent },
            { path: 'about', component: AboutComponent },
            { path: '**', redirectTo: 'qcwapi' }
        ])
    ]
})
export class AppModuleShared {
}
