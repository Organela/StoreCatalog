import { Component, EventEmitter, Input, Output } from '@angular/core';

import { Product } from '../shared/product.model';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent {

  @Input() baseRoute: string;
  @Input() item: Product;
  @Output() deleteClick = new EventEmitter();
}
