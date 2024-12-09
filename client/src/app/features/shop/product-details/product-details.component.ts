import { Component, inject, OnInit } from '@angular/core';
import { ShopService } from '../../../core/servicse/shop.service';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Product } from '../../../shared/models/product';
import { MatButton } from '@angular/material/button';
import { CurrencyPipe } from '@angular/common';
import { MatIcon } from '@angular/material/icon';
import { MatDivider } from '@angular/material/divider';
import { MatLabel } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-product-details',
  imports: [
    MatButton,
    CurrencyPipe,
    MatIcon,
    MatDivider,
    MatLabel,
    MatInputModule
  ],
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.scss'
})
export class ProductDetailsComponent implements OnInit {
  private shopService = inject(ShopService);
  private activeedRoute = inject(ActivatedRoute);
  product?: Product;

  ngOnInit(): void {
    this.loadProduct();
  }
  loadProduct() {
    const id = this.activeedRoute.snapshot.paramMap.get('id');
    if(!id) return;
    this.shopService.getProduct(+id).subscribe({
      next: product => this.product = product,
      error: error => console.log(error)
    })
  }
}
