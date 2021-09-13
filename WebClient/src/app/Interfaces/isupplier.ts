import { IModel } from './imodel';

export interface ISupplier extends IModel {
	emailAddress: string;
	phoneNumber: string;
}
