export class Seguro {
    id: number = 0;
    cpfCnpj: string = '';
    tipo: string = '';
    
    placa?: string = null;

    cpfSegurado?: string = null;

    rua?: string = null;
    numero?: string = null;
    bairro?: string = null;
    cidade?: string = null;

    constructor(init?: Partial<Seguro>) {
        Object.assign(this, init);
    }

    get logradouro() {
        if(this.numero) {
            return `${this.rua}, nº ${this.numero}`;
        }

        return `${this.rua}, s/nº`;
    }

    get placaFormatada() {
        if(!this.placa) {
            return '';
        }
        
        return this.placa.substr(0, 3) + '-' + this.placa.substr(3, 4);
    }
}