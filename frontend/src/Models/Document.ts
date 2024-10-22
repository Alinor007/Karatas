export type DocumentGet = {
    id: number;         // Assuming you'll want to include the id when retrieving documents
    name: string;
    description: string;  // This can represent some document description field
    status: boolean;     // Status of document (approved or not)
    userId?: string;     // Optional field for UserId
    created: Date;       // Date when the document was created
    updated: Date;       // Date when the document was last updated
  };
  
  // Type for posting document data (to API)
  export type DocumentPost = {
    name: string;
    description: string;  // Description of the document when creating it
  };