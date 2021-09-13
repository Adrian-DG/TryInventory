import { IModel } from './imodel';
import { IProduct } from './iproduct';

export interface IBrand extends IModel {
	products: IProduct[];
}
