import { Seguro } from './seguro';

export class SalvarSeguro {
    cpfCnpj: string = '';
    tipo: string = '';
    codigoTipo: number = 0;

    cpfSegurado?: string = '';
    
    rua?: string = '';
    numero?: number = 0;
    bairro?: string = '';
    cidade?: string = '';
    
    placa?: string = '';

    constructor(init?: Partial<Seguro>) {
        Object.assign(this, init);
    }
}