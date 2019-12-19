import { Users } from './user.model';

export class RoleViewModel {
    public Id: string = null;
    public Name: string = null;
    public Users: Users[] = [];
}