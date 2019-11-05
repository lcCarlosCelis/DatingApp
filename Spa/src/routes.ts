import { HomeComponent } from './app/home/home.component';

export const appRoutes = [
    { path:'home', component: HomeComponent },
    { path: '**', redirectTo: 'home' }
]