
export interface AggregateRoot<TKey> extends BasicAggregateRoot<TKey> {
  extraProperties: Record<string, object>;
  concurrencyStamp: string;
}

export interface BasicAggregateRoot<TKey> extends Entity<TKey> {
}

export interface Entity {
}

export interface Entity<TKey> extends Entity {
  id: TKey;
}
