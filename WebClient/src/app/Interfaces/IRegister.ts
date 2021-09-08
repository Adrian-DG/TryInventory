import { Gender } from '../Enums/gender.enum';
export interface IRegister {
	firstname: string;
	lastname: string;
	username: string;
	emailAddress: string;
	doB: Date;
	phoneNumber: string;
	gender: Gender;
	password: string;
}
