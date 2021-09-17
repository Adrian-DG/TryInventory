export interface IModel {
	id: string | null;
	name: string;
	created: Date | null;
	modified: Date | null;
	status: boolean;
	userId: string;
}
