export interface Nota {
    id: number;
    nombre: string;
    valor: number;
    idProfesor :number;
    idEstudiante: number;
}

export interface ResponseBaseNota {
    codigoDeError: number;
    mensaje: string;
    response: any;
}

export interface ReporteNota {
    id: number;
    nombre: string;
    valor: number;
    profesor :string;
    estudiante: string;
}