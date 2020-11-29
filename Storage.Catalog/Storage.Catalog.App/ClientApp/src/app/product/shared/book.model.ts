import { Product } from './product.model';

export interface Book extends Product {
    author?: string;
}