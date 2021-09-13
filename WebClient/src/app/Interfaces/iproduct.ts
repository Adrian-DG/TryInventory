import { Category } from '../Enums/category.enum';
import { IBrand } from './ibrand';
import { IModel } from './imodel';
import { ISupplier } from './isupplier';

export interface IProduct extends IModel {
	brand: IBrand;
	supplier: ISupplier;
	category: Category;
	price: number;
	inStock: number;
}
