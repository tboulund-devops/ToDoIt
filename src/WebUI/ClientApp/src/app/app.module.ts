import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { tasksComponent } from './Tasks/Tasks.component';
import { createTaskComponent } from './create-task/CreateTask.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    tasksComponent,
    createTaskComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: tasksComponent, pathMatch: 'full' },
      { path: 'fetch-data', component: createTaskComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
