export interface Document  {
  id: string;
  controlNumber: string;
  type: 'Contract' | 'Invoice' | 'Report' | 'Proposal';
  status: 'Draft' | 'Pending' | 'Approved' | 'Rejected';
  owner: string;
  created: string;
  title: string;
  priority: 'Low' | 'Medium' | 'High';
  };
  
  // Type for posting document data (to API)
  export interface DocumentPost {
    name: string;
    description: string;  // Description of the document when creating it
  };

  export interface UpdateDocument extends DocumentPost{}