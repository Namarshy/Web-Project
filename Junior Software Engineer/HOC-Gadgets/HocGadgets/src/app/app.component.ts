import { Component } from '@angular/core';
import { RouterOutlet,RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common'; 
import { InventoryComponent } from './AppComponent/inventory/inventory.component';
import { CustomerComponent } from './AppComponents/customer/customer.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterModule,InventoryComponent,CommonModule,CustomerComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'HocGadgets';
}
