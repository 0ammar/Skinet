import { Component, inject } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { CartService } from '../../../core/services/cart.service';
import { CartItemComponent } from '../../../core/services/cart-item/cart-item.component';

@Component({
  selector: 'app-empty-state',
  imports: [MatIcon, MatButton, RouterLink],
  templateUrl: './empty-state.component.html',
  styleUrl: './empty-state.component.scss',
})
export class EmptyStateComponent {
  cartService = inject(CartService);
}
