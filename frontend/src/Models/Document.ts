export interface Document  {
  id: string;
  title: string;
  trackingNumber: string;
  status: 'Draft' | 'Pending' | 'Approved' | 'Rejected';
  type: 'Contract' | 'Invoice' | 'Report' | 'Proposal';
  ownerId: string;
  dateCreated: string;
  dateUpdated: string;
  };
  
  // Type for posting document data (to API)
  export interface DocumentPost {
  
    Title: string;
    TrackingNumber: string;
    Status: 'Draft' | 'Pending' | 'Approved' | 'Rejected';
    Type: 'Contract' | 'Invoice' | 'Report' | 'Proposal';
    OwnerId: string;
    DateCreated: string;
  };

  export interface UpdateDocument {

    
    Title: string;
    TrackingNumber: string;
    Status: 'Draft' | 'Pending' | 'Approved' | 'Rejected';
    Type: 'Contract' | 'Invoice' | 'Report' | 'Proposal';
    OwnerId: string;
    DateUpdated: string;
  
  }