import { HomeComponent } from './app/home/home.component';
import { UserComponent } from './app/user/user.component';
import { AuthGuard } from './app/_guards/auth.guard';

export const appRoutes = [
    { path:'home', component: HomeComponent },
    { path: 'user', component: UserComponent, canActivate: [AuthGuard] },
    { path: '**', redirectTo: 'home' }
]
