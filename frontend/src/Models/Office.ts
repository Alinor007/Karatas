export interface Office {
  id: number;
  name: string;
  stage: string;
  description: string;
  updated: string;
}

export interface CreateOfficeDTO {
  name: string;
  stage: string;
  description: string;
}

export interface UpdateOfficeDTO extends CreateOfficeDTO {}